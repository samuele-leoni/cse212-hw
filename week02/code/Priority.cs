public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: Six people names are added with different priorities at different times.
        // Bob, Tim, Sue will be added immediately having a priority respectively of: 2, 3, 1.
        // One will be removed (Tim: 3 in this case) and George: 2, John: 4, Jack: 5 will be added.
        // The dequeue will be called in a loop until the Queue is empty. 
        // Expected Result: Tim, Jack, John, Bob, George, Sue.
        Console.WriteLine("Test 1");

        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Tim", 3);
        priorityQueue.Enqueue("Sue", 1);

        Console.WriteLine(priorityQueue.Dequeue());

        priorityQueue.Enqueue("George", 2);
        priorityQueue.Enqueue("John", 4);
        priorityQueue.Enqueue("Jack", 5);

        for(int i = 0; i < 5; i++)
        {
            Console.WriteLine(priorityQueue.Dequeue());
        }

        // Defect(s) Found: The Dequeue method does not cycle through the whole queue to find the highest priority, it misses
        // the last index, also the check should be if the current value is greater than but not equal, otherwise the queue 
        // order won't be followed. Also, the Dequeue method does not dequeue the item, it just returns it.

        Console.WriteLine("---------");

        // Test 2
        // Scenario: The dequeue will be called on an empty queue
        // Expected Result: Error shown
        Console.WriteLine("Test 2");

        priorityQueue.Dequeue();

        // Defect(s) Found: None

        Console.WriteLine("---------");

        // Add more Test Cases As Needed Below
    }
}