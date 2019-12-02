using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class mainSystem : MonoBehaviour {

    private string archivesPath;
    private int gameCount = 0;
    private RenderTexture rt;

    private void Awake() {
        archivesPath = Application.dataPath + "/../GameArchives/";
        //フォルダ生成
        folderAndFileCreate();
    }

    void Start() {

    }

    void Update() {

    }

    private void folderAndFileCreate() {
        //アーカイブフォルダが存在しないなら作る
        if (!Directory.Exists(@archivesPath)) {
            DirectoryInfo di = Directory.CreateDirectory(@archivesPath);
        }
        //OXフォルダがないなら作る
        if (!Directory.Exists(archivesPath + "0X/")) {
            DirectoryInfo dii = Directory.CreateDirectory(archivesPath + "0X/");
        }
        if (Directory.GetFiles(archivesPath + "0X/", "readme.txt", SearchOption.TopDirectoryOnly).Length == 0) {
            string filePath = archivesPath + "0X/readme.txt";
            StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine(readmeData());
            sw.Flush();
            sw.Close();
        }
        if (Directory.GetFiles(archivesPath + "0X/", "example.exe", SearchOption.TopDirectoryOnly).Length == 0) {
            string filePath = archivesPath + "0X/example.exe";
            StreamWriter sw = new StreamWriter(filePath, true);
            sw.Flush();
            sw.Close();
        }
        if (Directory.GetFiles(archivesPath + "0X/", "abstruct.txt", SearchOption.TopDirectoryOnly).Length == 0) {
            string filePath = archivesPath + "0X/abstruct.txt";
            StreamWriter sw = new StreamWriter(filePath, true);
            sw.Flush();
            sw.Close();
        }
        if (Directory.GetFiles(archivesPath + "0X/", "movie.ogg", SearchOption.TopDirectoryOnly).Length == 0) {
            string filePath = archivesPath + "0X/movie.ogg";
            StreamWriter sw = new StreamWriter(filePath, true);
            sw.Flush();
            sw.Close();
        }


        countGameFolder();

        for (int i = 1; i <= gameCount; i++) {
            if (!Directory.Exists(Application.dataPath + "/Resources/0" + i.ToString() + "/")) {
                Debug.Log("ok");
                DirectoryInfo di = Directory.CreateDirectory(Application.dataPath + "/Resources/0" + i.ToString() + "/");
                rt = new RenderTexture(1920, 1080, 24, RenderTextureFormat.ARGB32);
                Debug.Log(rt.IsCreated());
                //RenderTextureCreationFlags
                //  renderTextureCreation
                //   RenderTextureDescriptor
                rt.Create();
                rt.name = "RenderTextureVideo";

            }
            if (i >= 9) {
                for (; i <= gameCount; i++) {
                    if (!Directory.Exists(Application.dataPath + "/Resources/" + i.ToString() + "/")) {
                        DirectoryInfo di = Directory.CreateDirectory(Application.dataPath + "/Resources/" + i.ToString() + "/");
                        rt = new RenderTexture(1920, 1080, 24, RenderTextureFormat.ARGB32);
                        rt.Create();
                        rt.name = "RenderTextureVideo";
                    }
                    if (i >= 99) {
                        return;
                    }
                }
                return;
            }
        }

    }

    //ゲームフォルダの数を数える
    private void countGameFolder() {
        for (int i = 1; Directory.Exists(archivesPath + "0" + i.ToString() + "/"); i++) {
            gameCount++;
            if (i >= 9) {
                for (; Directory.Exists(archivesPath + i.ToString() + "/"); i++) {
                    gameCount++;
                    if (i >= 99) {
                        return;
                    }
                }
                return;
            }
        }
    }

    private string readmeData() {
        return "";
    }
}
