﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="PartitionResolver" /> class.
    /// </summary>
    ///
    [TestFixture]
    public class PartitionResolverTests
    {
        /// <summary>
        ///   Provides the test cases for different sets of partitions.
        /// </summary>
        ///
        public static IEnumerable<object[]> PartitionSetTestCases()
        {
            // Build some basic partition sets with 8 or less partitions.

            for (var index = 1; index < 8; ++index)
            {
                yield return new object[] { Enumerable.Range(0, index).Select(item => item.ToString()).ToArray() };
            }

            // Build sets for 16, 32, and 2000 partitions for more extreme cases.

            foreach (var count in new[] { 16, 32, 2000 })
            {
                yield return new object[] { Enumerable.Range(0, count).Select(item => item.ToString()).ToArray() };
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionResolver.AssignRoundRobin" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(PartitionSetTestCases))]
        public void RoundRobinDistributesFairly(string[] partitions)
        {
            var resolver = new PartitionResolver();

            for (var index = 0; index < 100; index++)
            {
                var expected = partitions[index % partitions.Length];
                var assigned = resolver.AssignRoundRobin(partitions);

                Assert.That(assigned, Is.EqualTo(expected), $"The assignment was unexpected for index: [{ index }].");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionResolver.AssignRoundRobin" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(PartitionSetTestCases))]
        public async Task RoundRobinDistributesFairlyWhenCalledConcurrently(string[] partitions)
        {
            var concurrentCount = 4;
            var assignmentsPerPartition = 20;
            var iterationCount = partitions.Length * assignmentsPerPartition;
            var resolver = new PartitionResolver();
            var assigned = new List<string>();
            var activeTasks = new List<Task>();

            // Create a function that assigns partitions in a loop and track them.

            Task roundRobin()
            {
                for (var index = 0; index < iterationCount; index++)
                {
                    assigned.Add(resolver.AssignRoundRobin(partitions));
                }

                return Task.CompletedTask;
            }

            // Run assignment concurrently.

            for (var concurrentIndex = 0; concurrentIndex < concurrentCount; ++concurrentIndex)
            {
               activeTasks.Add(roundRobin());
            }

            await Task.WhenAll(activeTasks);

            // When grouped, the count of each partition should equal the iteration count for each
            // concurrent invocation.

            var partitionAssignments = assigned
                .GroupBy(item => item)
                .Select( group => new { Key = group.Key, Count = group.Count() });

            var assignmentHash = new HashSet<string>();
            var expectedAssignmentCount = (concurrentCount * assignmentsPerPartition);

            // Verify that each assignment is for a valid partition and has the expected distribution.

            foreach (var partitionAssignment in partitionAssignments)
            {
                Assert.That(partitionAssignment.Count, Is.EqualTo(expectedAssignmentCount), $"The count for key: [{ partitionAssignment.Key}] should match the total number of iterations.");
                assignmentHash.Add(partitionAssignment.Key);
            }

            // Verify that all partitions were assigned.

            foreach (var partition in partitions)
            {
                Assert.That(assignmentHash.Contains(partition), Is.True, $"Partition: [{ partition }] should have had assignments.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionResolver.AssignRoundRobin" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(PartitionSetTestCases))]
        public void RoundRobinRollsOverFairly(string[] partitions)
        {
            var assignmentsPerPartition = 20;
            var iterationCount = partitions.Length * assignmentsPerPartition;
            var resolver = new PartitionResolver();
            var assigned = new List<string>();

            // Set the starting index for the resolver to something just below the
            // rollover point.

            SetPartitionIndex(resolver, (int.MaxValue - 4));

            for (var index = 0; index < iterationCount; index++)
            {
                assigned.Add(resolver.AssignRoundRobin(partitions));
            }

            // When grouped, the count of each partition should equal the iteration count for each
            // concurrent invocation.

            var partitionAssignments = assigned
                .GroupBy(item => item)
                .Select( group => new { Key = group.Key, Count = group.Count() });

            var assignmentHash = new HashSet<string>();

            // Verify that each assignment is for a valid partition and has the expected distribution.  Because
            // rollover can cause a small bit of assignment overlap due to the sequence change, allow for a small degree
            // of variance from the perfect fair distribution.

            foreach (var partitionAssignment in partitionAssignments)
            {
                Assert.That(partitionAssignment.Count, Is.EqualTo(assignmentsPerPartition).Within(2), $"The count for key: [{ partitionAssignment.Key}] should match the total number of iterations.");
                assignmentHash.Add(partitionAssignment.Key);
            }

            // Verify that all partitions were assigned.

            foreach (var partition in partitions)
            {
                Assert.That(assignmentHash.Contains(partition), Is.True, $"Partition: [{ partition }] should have had assignments.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionResolver.AssignRoundRobin" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(PartitionSetTestCases))]
        public async Task RoundRobinRollsOverFairlyWhenCalledConcurrently(string[] partitions)
        {
            var concurrentCount = 4;
            var assignmentsPerPartition = 20;
            var iterationCount = partitions.Length * assignmentsPerPartition;
            var resolver = new PartitionResolver();
            var assigned = new List<string>();
            var activeTasks = new List<Task>();

            // Set the starting index for the resolver to something just below the
            // rollover point.

            SetPartitionIndex(resolver, (int.MaxValue - 4));

            // Create a function that assigns partitions in a loop and track them.

            Task roundRobin()
            {
                for (var index = 0; index < iterationCount; index++)
                {
                    assigned.Add(resolver.AssignRoundRobin(partitions));
                }

                return Task.CompletedTask;
            }

            // Run assignment concurrently.

            for (var concurrentIndex = 0; concurrentIndex < concurrentCount; ++concurrentIndex)
            {
               activeTasks.Add(roundRobin());
            }

            await Task.WhenAll(activeTasks);

            // When grouped, the count of each partition should equal the iteration count for each
            // concurrent invocation.

            var partitionAssignments = assigned
                .GroupBy(item => item)
                .Select( group => new { Key = group.Key, Count = group.Count() });

            var assignmentHash = new HashSet<string>();
            var expectedAssignmentCount = (concurrentCount * assignmentsPerPartition);

            // Verify that each assignment is for a valid partition and has the expected distribution.  Because
            // rollover can cause a small bit of assignment overlap due to the sequence change, allow for a small degree
            // of variance from the perfect fair distribution.

            foreach (var partitionAssignment in partitionAssignments)
            {
                Assert.That(partitionAssignment.Count, Is.EqualTo(expectedAssignmentCount).Within(2), $"The count for key: [{ partitionAssignment.Key}] should match the total number of iterations.");
                assignmentHash.Add(partitionAssignment.Key);
            }

            // Verify that all partitions were assigned.

            foreach (var partition in partitions)
            {
                Assert.That(assignmentHash.Contains(partition), Is.True, $"Partition: [{ partition }] should have had assignments.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionResolver.AssignRoundRobin" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(PartitionSetTestCases))]
        public void PartitionKeyAssignmentIsStable(string[] partitions)
        {
            var iterationCount = 25;
            var key = "this-is-a-key-1";
            var resolver = new PartitionResolver();
            var expected = resolver.AssignForPartitionKey(key, partitions);

            for (var index = 0; index < iterationCount; ++index)
            {
                Assert.That(resolver.AssignForPartitionKey(key, partitions), Is.EqualTo(expected), $"The assignment for iteration: [{ index }] was unstable.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionResolver.AssignRoundRobin" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(PartitionSetTestCases))]
        public void PartitionKeyAssignmentDistributesKeysToDifferentPartitions(string[] partitions)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var keyLength = 20;
            var requiredAssignments = (int)Math.Floor(partitions.Length * 0.67);
            var assignedHash = new HashSet<string>();
            var resolver = new PartitionResolver();

            // Create the random number generator using a constant seed; this is
            // intended to allow for randomization but will also keep a consistent
            // pattern each time the tests are run.

            var rng = new Random(412);

            for (var index = 0; index < int.MaxValue; ++index)
            {
                var keyBuilder = new StringBuilder(keyLength);

                for (var charIndex = 0; charIndex < keyLength; ++charIndex)
                {
                    keyBuilder.Append((char)rng.Next(1, 256));
                }

                var key = keyBuilder.ToString();
                var partition = resolver.AssignForPartitionKey(key, partitions);

                assignedHash.Add(partition);

                // If keys were distributed to more than one partition and the minimum number of
                // iterations was satisfied, break the loop.

                if (assignedHash.Count > requiredAssignments)
                {
                    break;
                }

                cancellationSource.Token.ThrowIfCancellationRequested();
            }

            Assert.That(assignedHash.Count, Is.GreaterThanOrEqualTo(requiredAssignments), "Partition keys should have had some level of distribution among partitions.");
        }

        /// <summary>
        ///   Sets the partition index for a <see cref="PartitionResolver" />
        ///   by directly accessing its private field.
        /// </summary>
        ///
        /// <param name="target">The instance to set the index of.</param>
        /// <param name="partitionIndexValue">The value to set the index to.</param>
        ///
        private static void SetPartitionIndex(PartitionResolver target,
                                              int partitionIndexValue) =>
            typeof(PartitionResolver)
                .GetField("_partitionAssignmentIndex", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(target, partitionIndexValue);
    }
}
