using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items to the priority queue with different priority values and dequeue the item with the highest priority.
    // Expected Result: Bob should be returned first because he has the highest priority (5).
    // Defect(s) Found: No Defect(s) found
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alice", 2);
        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Charlie", 1);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Bob", result);
    }

    [TestMethod]
    // Scenario: Add three items to the priority queue with the highest-priority item at the end of the queue and dequeue the highest-priority item.
    // Expected Result: Charlie should be returned first because he has the highest priority (10).
    // Defect(s) Found: The loop in Dequeue does not check the last item in the queue, so a highest-priority item at the end can be missed.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alice", 2);
        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Charlie", 10);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Charlie", result);
    }

    // Add more test cases as needed below.
}