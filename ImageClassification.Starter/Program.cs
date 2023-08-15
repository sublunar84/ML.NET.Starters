var projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../"));
var assetsRelativePath = Path.Combine(projectDirectory, "assets");
var workspaceRelativePath = Path.Combine(projectDirectory, "workspace");
var testRelativePath = Path.Combine(projectDirectory, "test");

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
	// Ladda in data från bilderna i assets-mappen
	IEnumerable<ImageData> images = LoadImagesFromDirectory(folder: assetsRelativePath, useFolderNameAsLabel: true);

	// Ladda in bilderna i en IDataView
	// Gör en preproccessing-pipeline
	// Dela upp i test- och träningsdata
	// Skapa classifierOptions
	// Skapa pipeline utifrån classifierOptions
	// Träna modellen på träningsdata
	// Spara modellen i workspace-mappen
	// Utvärdera modellen
	
}


static void OutputPrediction(ModelOutput prediction)
{
	string imageName = Path.GetFileName(prediction.ImagePath);
	Console.WriteLine($"Image: {imageName} | Actual Value: {prediction.Label} | Predicted Value: {prediction.PredictedLabel} | Score: {prediction.Score.Max()}");
}

IEnumerable<ImageData> LoadImagesFromDirectory(string folder, bool useFolderNameAsLabel = true)
{
	var files = Directory.GetFiles(folder, "*",
	searchOption: SearchOption.AllDirectories);

	foreach (var file in files)
	{
		if ((Path.GetExtension(file) != ".jpg") && (Path.GetExtension(file) != ".png"))
			continue;

		var label = Path.GetFileName(file);

		if (useFolderNameAsLabel)
			label = Directory.GetParent(file).Name;
		else
		{
			for (int index = 0; index < label.Length; index++)
			{
				if (!char.IsLetter(label[index]))
				{
					label = label.Substring(0, index);
					break;
				}
			}
		}

		yield return new ImageData()
		{
			ImagePath = file,
			Label = label
		};
	}
}

void MakePredictions()
{
	// Ladda in modellen
	// Ladda in bilder från test-mappen
	IEnumerable<ImageData> images = LoadImagesFromDirectory(testRelativePath, useFolderNameAsLabel: true);
	// Ladda in bilderna i en IDataView
	// Gör en preproccessing-pipeline
	// Skapa en lista av imageInputs från Enumerable
	// Skapa en prediction engine
	// Gör förutsägelser genom att loopa igenom imageInputs och anropa OutputPrediction för varje prediction
}

public class ImageData
{
	public string ImagePath { get; set; }

	public string Label { get; set; }
}

class ModelInput
{
	public byte[] Image { get; set; }

	public UInt32 LabelAsKey { get; set; }

	public string ImagePath { get; set; }

	public string Label { get; set; }
}

public class ModelOutput
{
	public string ImagePath { get; set; }

	public string Label { get; set; }

	public string PredictedLabel { get; set; }

	public float[]? Score { get; set; }
}