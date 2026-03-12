public class Node
{
    public int Value {get; private set;}
    public Node? Left;
    public Node? Right;

    public Node(int i)
    {
        Value = i;
        Left = null;
        Right = null;
    }
    public Node(int i, Node l, Node r)
    {
        Value = i;
        Left = l;
        Right = r;
    }
}