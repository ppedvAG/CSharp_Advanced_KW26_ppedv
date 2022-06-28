// See http
//

Node<SolarItem> sunNode = new Node<SolarItem>(new SolarItem("Sonne", SolarItemType.Star));

Node<SolarItem> merkurNode = new Node<SolarItem>(new SolarItem("Merkur", SolarItemType.Planet));
Node<SolarItem> venusNode = new Node<SolarItem>(new SolarItem("Venus", SolarItemType.Planet));

Node<SolarItem> earthNode = new Node<SolarItem>(new SolarItem("Erde", SolarItemType.Planet));
earthNode.AddChild(new SolarItem("Mond", SolarItemType.Trabant));

Node<SolarItem> marsNode = new Node<SolarItem>(new SolarItem("Mars", SolarItemType.Planet));
marsNode.AddChild(new SolarItem("Phobos", SolarItemType.Trabant));
marsNode.AddChild(new SolarItem("Deimos", SolarItemType.Trabant));

Node<SolarItem> jupiterNode = new Node<SolarItem>(new SolarItem("Jupiter", SolarItemType.Planet));
jupiterNode.AddChild(new SolarItem("Europa", SolarItemType.Trabant));
jupiterNode.AddChild(new SolarItem("Io", SolarItemType.Trabant));
jupiterNode.AddChild(new SolarItem("Ganymed", SolarItemType.Trabant));
jupiterNode.AddChild(new SolarItem("Kallisto", SolarItemType.Trabant));
jupiterNode.AddChild(new SolarItem("Metis", SolarItemType.Trabant));
jupiterNode.AddChild(new SolarItem("Adrastea", SolarItemType.Trabant));
jupiterNode.AddChild(new SolarItem("Amalthea", SolarItemType.Trabant));
jupiterNode.AddChild(new SolarItem("Thebe", SolarItemType.Trabant));

Node<SolarItem> saturnNode = new Node<SolarItem>(new SolarItem("Saturn", SolarItemType.Planet));
saturnNode.AddChild(new SolarItem("Titan", SolarItemType.Trabant));
saturnNode.AddChild(new SolarItem("Rhea", SolarItemType.Trabant));
saturnNode.AddChild(new SolarItem("Dione", SolarItemType.Trabant));
saturnNode.AddChild(new SolarItem("Tethys", SolarItemType.Trabant));
saturnNode.AddChild(new SolarItem("Japetus", SolarItemType.Trabant));
saturnNode.AddChild(new SolarItem("Telesto", SolarItemType.Trabant));
saturnNode.AddChild(new SolarItem("Calypso", SolarItemType.Trabant));
saturnNode.AddChild(new SolarItem("Tethys", SolarItemType.Trabant));

Node<SolarItem> uranusNode = new Node<SolarItem>(new SolarItem("Uranus", SolarItemType.Planet));
uranusNode.AddChild(new SolarItem("Miranda", SolarItemType.Trabant));
uranusNode.AddChild(new SolarItem("Ariel", SolarItemType.Trabant));
uranusNode.AddChild(new SolarItem("Umbriel", SolarItemType.Trabant));
uranusNode.AddChild(new SolarItem("Titania", SolarItemType.Trabant));
uranusNode.AddChild(new SolarItem("Oberon", SolarItemType.Trabant));
uranusNode.AddChild(new SolarItem("Triton", SolarItemType.Trabant));

Node<SolarItem> neptunNode = new Node<SolarItem>(new SolarItem("Neptun", SolarItemType.Planet));
neptunNode.AddChild(new SolarItem("Triton", SolarItemType.Trabant));
neptunNode.AddChild(new SolarItem("Proteus", SolarItemType.Trabant));
neptunNode.AddChild(new SolarItem("Halimede", SolarItemType.Trabant));
neptunNode.AddChild(new SolarItem("Nereid", SolarItemType.Trabant));
neptunNode.AddChild(new SolarItem("Naiad", SolarItemType.Trabant));
neptunNode.AddChild(new SolarItem("Thalasaa", SolarItemType.Trabant));


sunNode.AddChild(merkurNode);
sunNode.AddChild(venusNode);
sunNode.AddChild(earthNode);
sunNode.AddChild(marsNode);
sunNode.AddChild(jupiterNode);
sunNode.AddChild(saturnNode);
sunNode.AddChild(uranusNode);
sunNode.AddChild(neptunNode);



DisplaySolarSystem(sunNode);

void DisplaySolarSystem(Node<SolarItem> solarNode)
{
    if (solarNode.Item.Type == SolarItemType.Star)
        Console.WriteLine($"Stern: {solarNode.Item.Description}");

    if (solarNode.Item.Type == SolarItemType.Planet)
        Console.WriteLine($"Planet: {solarNode.Item.Description} - kreist um {solarNode.ParentNode.Item.Description}");

    if (solarNode.Item.Type == SolarItemType.Trabant)
        Console.WriteLine($"Trabant: {solarNode.Item.Description} - kreist um {solarNode.ParentNode.Item.Description}");


    if (solarNode.Item.Type != SolarItemType.Trabant)
    {
        foreach (Node<SolarItem> node in solarNode.Children)
            DisplaySolarSystem(node);
    }
}

public record SolarItem(string Description, SolarItemType Type);

public enum SolarItemType { Star, Planet, Trabant }

public class Node<T> where T : class
{
    private T _item;

    private Node<T> _parentNode = default!;

    private List<Node<T>> _children = new List<Node<T>>();

    #region Konstruktoren
    //Sonne
    public Node(T item)
    {
        Item = item;
    }


    //Planet oder Mond
    public Node(T item, Node<T> parentNode)
        : this(item)
    {
        ParentNode = parentNode;
    }
    #endregion

    #region  Properties
    public Node<T> ParentNode { get => _parentNode; set => _parentNode = value; }
    public List<Node<T>> Children { get => _children; set => _children = value; }
    public T Item { get => _item; set => _item = value; }
    #endregion

    public void AddChild(T child)
    {
        Children.Add(new Node<T>(child, this));
    }

    public void AddChild(Node<T> child)
    {
        child.ParentNode = this;
        Children.Add(child);
    }
}