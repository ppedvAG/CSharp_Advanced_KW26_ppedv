namespace PluginBase
{
    //Dll wird bei einem Plugin-Fähigen Produkt zum Download angeboten 
    public interface ICommand //Schnittstelle des Interfaces
    {
        string Name { get; } //PluginName 
        string Description { get; } 

        int Execute(); //Das Plugin Implementiert in Execute seine eigene Logik 
                       //Die App ruft lediglich ICommand.Execute auf und kann somit, die Logik eines Plugins ausführen

        //.... 
    }
}
