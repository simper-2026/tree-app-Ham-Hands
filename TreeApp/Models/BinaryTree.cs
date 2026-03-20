public class BinaryTree
{
    public Node? Root;
    private int Index;
    public BinaryTree()
    { }
    public void Insert(int value)
    {
        // Adds the root if there isn't one yet
        if (Root == null)
        {
            Root = new Node(value);
            return;
        }

        AddNode(new Node(value), Root);

        Root = balanceTree(Root);
    }
    private void AddNode(Node child, Node parent)
    {
        if (child.Value < parent.Value)
        {
            if (parent.Left == null)
            {
                parent.Left = child;
                return;
            }
            else if (parent.Left.Value != child.Value)
            {
                AddNode(child, parent.Left);
            }
        }
        else if (child.Value > parent.Value)
        {
            if (parent.Right == null)
            {
                parent.Right = child;
                return;
            }
            else if (parent.Right.Value != child.Value)
            {
                AddNode(child, parent.Right);
            }
        }
    }
    private Node balanceTree(Node node)
    {
        int left = 0;
        int right = 0;
        
        if(node.Left == null && node.Right == null)
        {
            return node;
        }
        
        if (node.Left != null)
        {    
            left = checkTreeHeight(node.Left);
        }
        if (node.Right != null)
        {            
            right = checkTreeHeight(node.Right);
        }

        if(left - right > 1)
        {
            node = RotateRight(node);
        }
        else if(left - right < -1)
        {
            node = RotateLeft(node);
        }
        
        if(node.Left != null)
            node.Left = balanceTree(node.Left);
        if(node.Right != null)
            node.Right = balanceTree(node.Right);

        return node;
    }
    public string InOrder(Node node)
    {
        string inOrder = "";
        if (node.Left != null)
        {
            inOrder += InOrder(node.Left);
        }

        inOrder += $"{node.Value}, ";

        if (node.Right != null)
        {
            inOrder += InOrder(node.Right);
        }

        return inOrder;
    }
    public int Height()
    {
        int count = -1;

        if (Root == null)
        { }
        else
        {
            count += checkTreeHeight(Root);
        }

        return count;
    }
    private int checkTreeHeight(Node node)
    {
        int maxHeight = 1;
        int Left = 0;
        int Right = 0;

        if (node.Left != null && node.Left != node)
        {
            Left = checkTreeHeight(node.Left);
        }

        if (node.Right != null && node.Right != node)
        {
            Right = checkTreeHeight(node.Right);
        }

        if (Left > Right || (Left == Right && Left != 0))
        {
            maxHeight += Left;
        }
        else if (Right > Left)
        {
            maxHeight += Right;
        }


        return maxHeight;
    }
    public string ToMermaid()
    {
        string toReturn = "graph TD\n";
        int height = Height() - 1;

        if (Root == null)
        {
            toReturn += " empty[\"(empty tree)\"]";
            return toReturn;
        }
        else if (Root.Left == null && Root.Right == null)
        {
            toReturn += $" {Root.Value}[ {Root.Value} h:0 ]";
            return toReturn;
        }
        else
        {
            Index = 0;
            toReturn += $" {Root.Value}[ {Root.Value} h:{height + 1} ]\n";
            toReturn += MermaidNodeString(Root, height);
        }

        return toReturn;
    }
    private string MermaidNodeString(Node node, int height)
    {
        string toReturn = "";

        if (node.Left != null)
        {
            Index++;
            toReturn += $" {node.Value} --> {node.Left.Value}[ {node.Left.Value} h:{height} ]\n";
            toReturn += MermaidNodeString(node.Left, height - 1);
        }
        else if (node.Left == null && node.Right != null)
        {
            toReturn += $" {node.Value} --> _ph{Index}[ ]\n";
            toReturn += $" linkStyle {Index} stroke:none,stroke-width:0,fill:none\n";
            toReturn += $" style _ph{Index} fill:none,stroke:none,color:none\n";
            Index++;
        }

        if (node.Right != null)
        {
            Index++;
            toReturn += $" {node.Value} --> {node.Right.Value}[ {node.Right.Value} h:{height} ]\n";
            toReturn += MermaidNodeString(node.Right, height - 1);
        }
        else if (node.Right == null && node.Left != null)
        {
            toReturn += $" {node.Value} --> _ph{Index}[ ]\n";
            toReturn += $" linkStyle {Index} stroke:none,stroke-width:0,fill:none\n";
            toReturn += $" style _ph{Index} fill:none,stroke:none,color:none\n";
            Index++;
        }

        return toReturn;
    }
    private Node RotateRight(Node node)
    {
        if (node.Left != null)
        {
            Node newNode = node.Left;
            if(newNode.Right != null)
            {
                Node node1 = newNode.Right;
                node.Left = node1;
            }
            else
            {
                node.Left = null;
            }
            newNode.Right = node;
            return newNode;
        }

        return node;
    }
    private Node RotateLeft(Node node)
    {
        if (node.Right != null)
        {
            Node newNode = node.Right;
            if (newNode.Left != null)
            {
                Node node1 = newNode.Left;
                node.Right = node1;
            }
            else
            {
                node.Right = null;
            }
            newNode.Left = node;
            return newNode;
        }

        return node;
    }
}