using System.IO;
using System.Text;


/**
 * Class to hold simulation configuration data
 * (Tentative)
 **/
public class Configuration{

	public string Title { get; set;}
	public string CreationDate { get; set;}
	public string CreationTime { get; set;}
	public string ModifiedDate { get; set;}
	public string ModifiedTime { get; set;}
	public string Description { get; set;}


	public static Configuration Parse(string path) {
		StreamReader theReader = new StreamReader (path, Encoding.Default);
		Configuration c = new Configuration ();
		using (theReader)
		{
			c.Title = theReader.ReadLine ();
			c.CreationDate = theReader.ReadLine ();
			c.CreationTime = theReader.ReadLine ();
			c.ModifiedDate = theReader.ReadLine ();
			c.ModifiedTime = theReader.ReadLine ();
			c.Description = theReader.ReadLine ();
			theReader.Close();
		}

		return c;
	}
}
