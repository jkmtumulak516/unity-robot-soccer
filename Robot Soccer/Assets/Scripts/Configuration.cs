using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


/**
 * Class to hold simulation configuration data
 * (Tentative)
 **/
[Serializable]
public class Configuration
{

	public string Title { get; set;}
	public DateTime CreationDateTime { get; set;}
	public DateTime ModifiedDateTime { get; set;}
	public string Description { get; set;}
    public int NumberOfRobots { get; set;}
    
    public Configuration()
    {
        Title = "Simulation";
        CreationDateTime = DateTime.Now;
        ModifiedDateTime = DateTime.Now;
        Description = "This is a simulation";
        NumberOfRobots = 3;
        
    }
    
    public static void Serialize(string file, Configuration c)
    {
        System.Xml.Serialization.XmlSerializer xs
            = new System.Xml.Serialization.XmlSerializer(c.GetType());

        using (StreamWriter writer = File.CreateText(file))
        {
            xs.Serialize(writer, c);
        }
            
    }

    public static Configuration Deserialize(string file)
    {
        System.Xml.Serialization.XmlSerializer xs
           = new System.Xml.Serialization.XmlSerializer(
              typeof(Configuration));
        using (StreamReader reader = File.OpenText(file))
        {
            Configuration c = (Configuration)xs.Deserialize(reader);
            return c;
        }
    }

}
