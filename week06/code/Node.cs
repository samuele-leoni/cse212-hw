public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        //check if the value is == to Data, if it is, return, this way we avoid duplicates
        if (value == Data) return;
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // Base case, if value == Data it means that value is in the current Node, 
        // therefore it is contained and we return true
        if (value == Data) return true;
        // Left side if value < data
        if (value < Data)
        {
            // If left is null it returns false because we reached the end without finding the value
            if (Left is null)
                return false;
            // Otherwise retry calling the recursive function on the left node
            else
                return Left.Contains(value);
        }
        // Right side if value > data
        else
        {
            // If left is null it returns false because we reached the end without finding the value
            if (Right is null)
                return false;
            // Otherwise retry calling the recursive function on the right node
            else
                return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // Base case, if we reach a Node with no other connections return 1
        if (Left is null && Right is null) return 1;
        // Calculate the height for left and right and return the highest + 1, if one of them is null
        // its value is considered as 0
        return Math.Max((Left?.GetHeight() + 1) ?? 0, (Right?.GetHeight() + 1) ?? 0);
    }
}