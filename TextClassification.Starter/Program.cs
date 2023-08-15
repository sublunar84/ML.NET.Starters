var projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../"));
var assetsRelativePath = Path.Combine(projectDirectory, "assets");
var workspaceRelativePath = Path.Combine(projectDirectory, "workspace");

Console.WriteLine("Press A to train and save a model, press B to make predictions with a saved model");

var answer = Console.ReadKey();

switch (answer.KeyChar.ToString().ToUpper())
{
	case "A":
		TrainModel();
		break;
	case "B":
		MakePredictions();
		break;
	default:
		Console.WriteLine("Wrong answer!");
		break;

}

void TrainModel()
{
	// Ladda in data från csv-filen i assets-mappen
	// Skapa pipeline
	// Dela upp i test- och träningsdata
	// Träna modellen på träningsdata
	// Spara modellen i workspace-mappen
	// Utvärdera modellen
}

void MakePredictions()
{
	// Ladda in modellen
	// Skapa en prediction engine
	// Gör förutsägelser
}

// Lägg in valfria feature-kolumner från csv-filen i assets-mappen här samt kolumnen du vill förutsäga (label)
public class ModelInput
{


}

// Lägg in kolumnen du vill förutsäga från csv-filen i assets-mappen här (label-kolumnen), Score-kolumnen samt övrigt du behöver
public class ModelOutput
{

}