using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class dataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;    
    private GameData gameData;
    private List<IDataPersistance> dataPersistanceObjects;
    private fileDataHandler dataHandler;

    public static dataPersistanceManager instance { get; private set;}

    public void Awake()
    {
        if(instance != null)
        {
            Debug.Log("found more than one Data Persistance Manager in the scene. Destroyed the newbie");
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        this.dataHandler = new fileDataHandler(Application.persistentDataPath, fileName);
        DontDestroyOnLoad(this.gameObject);

    }
    private void Start()
    {
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();   
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        Debug.Log("loaded");
        //load any saved data from a file using the data handler
        this.gameData = dataHandler.Load();
        //if no data can be loaded, initialize to a new game
        if(this.gameData == null)
        {
            Debug.Log("no data was found. initialising data to defaults");
            NewGame();
        }

        //push the Loaded data to all other scripts that need it
        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }

    }
    public void SaveGame()
    {
        //pass the data to other scritps so they can update it
        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(gameData);
        }

        //save that data to a file using the data handler
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit() 
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}
