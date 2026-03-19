public class BinaryTree
{
    public List<Node> Tree;
    private int Index;
    public BinaryTree()
    {
        Tree = new List<Node>{};
    }
    public void Insert(int value)
    {
        // Adds the root if there isn't one yet
        if(!Tree.Any())
        {
            Tree.Add(new Node(value));
            return;
        }
        
        AddNode(new Node(value), Tree[0]);
    }
    private void AddNode(Node child, Node parent)
    {
        if(child.Value < parent.Value)
        {
            if(parent.Left == null)
            {
                parent.Left = child;
                return;
            }
            else if(parent.Left.Value != child.Value)
            {
                AddNode(child, parent.Left);
            }
        }
        else if(child.Value > parent.Value)
        {
            if(parent.Right == null)
            {
                parent.Right = child;
                return;
            }
            else if(parent.Right.Value != child.Value)
            {
                AddNode(child, parent.Right);
            }
        }
    }
    public string InOrder(Node node)
    {
        string inOrder = "";
        if(node.Left != null)
        {
            inOrder += InOrder(node.Left); 
        }

        inOrder += $"{node.Value}, ";

        if(node.Right != null)
        {
            inOrder += InOrder(node.Right);
        }

        return inOrder;
    }
    public int Height()
    {
        int count = -1;

        if(Tree.Count < 1)
        {}
        else
        {
            count += checkTreeHeight(Tree[0], count);
        }

        return count;
    }
    private int checkTreeHeight(Node node, int treeHeight)
    {
        int maxHeight = 0;
        int Left = 0;
        int Right = 0;

        maxHeight++;

        if(node.Left != null)
        {
            Left = checkTreeHeight(node.Left, treeHeight);
        }

        if(node.Right != null)
        {
            Right = checkTreeHeight(node.Right, treeHeight);
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
        
        if (Tree.Count < 1)
        {
            toReturn += " empty[\"(empty tree)\"]";
            return toReturn;
        }
        else if(Tree[0].Left == null && Tree[0].Right == null && Tree.Count == 1)
        {
            toReturn += $" {Tree[0].Value}";
            return toReturn;
        }
        else
        {
            Index = 0;
            toReturn += MermaidNodeString(Tree[0]);
        }

        return toReturn;
    }
    private string MermaidNodeString(Node node)
    {
        string toReturn = "";

        if(node.Left != null)
        {
            Index++;
            toReturn += $" {node.Value} --> {node.Left.Value}\n";
            toReturn += MermaidNodeString(node.Left);
        }
        else if(node.Left == null && node.Right != null)
        {
            toReturn += $" {node.Value} --> _ph{Index}[ ]\n";
            toReturn += $" linkStyle {Index} stroke:none,stroke-width:0,fill:none\n";
            toReturn += $" style _ph{Index} fill:none,stroke:none,color:none\n";
            Index++;
        }

        if(node.Right != null)
        {
            Index++;
            toReturn += $" {node.Value} --> {node.Right.Value}\n";
            toReturn += MermaidNodeString(node.Right);
        }
        else if(node.Right == null && node.Left != null)
        {
            toReturn += $" {node.Value} --> _ph{Index}[ ]\n";
            toReturn += $" linkStyle {Index} stroke:none,stroke-width:0,fill:none\n";
            toReturn += $" style _ph{Index} fill:none,stroke:none,color:none\n";
            Index++;
        }

        return toReturn;
    }
}