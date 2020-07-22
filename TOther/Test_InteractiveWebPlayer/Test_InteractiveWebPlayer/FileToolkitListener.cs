using System;
using System.Collections;
using System.IO;

public class FileToolkitListener
{
    /// <summary>
    /// LoadFile || 文件的读取
    /// </summary>
    /// <param name="path">FilePath || 文件的路径</param>
    /// <param name="name">FileName || 文件的名称（带后缀名）</param>
    /// <returns></returns>
    public static ArrayList LoadFile(string path, string name)
    {
        StreamReader sr = null;
        try
        {
            sr = File.OpenText(path + "//" + name);
        }
        catch (Exception e)
        {
            return null;
        }
        string line;
        ArrayList arrlist = new ArrayList();
        while ((line = sr.ReadLine()) != null)
        {
            arrlist.Add(line);
        }
        sr.Close();
        sr.Dispose();
        return arrlist;
    }

    /// <summary>
    /// DeleteFile || 文件的删除
    /// </summary>
    /// <param name="path">FilePath || 文件的路径</param>
    /// <param name="name">FileName || 文件的名称（带后缀名）</param>
    public static void DeleteFile(string path, string name)
    {
        FileInfo t = new FileInfo(path + "//" + name);
        t.Delete();
    }

    /// <summary>
    /// CreatFile || 文件的创建与写入
    /// </summary>
    /// <param name="path">FilePath || 文件的路径</param>
    /// <param name="name">FileName || 文件的名称（带后缀名）</param>
    /// <param name="info">FileInfo || 文件的内容</param>
    /// <param name="isOverride">FileIsOverride? || 文件是否覆盖？</param>
    public static void CreatFile(string path, string name, string info, bool isOverride)
    {
        StreamWriter sw;
        FileInfo t = new FileInfo(path + "//" + name);

        if (isOverride) t.Delete();

        if (!t.Exists)
        {
            sw = t.CreateText();
        }
        else
        {
            sw = t.AppendText();
        }
        sw.WriteLine(info);
        sw.Close();
        sw.Dispose();
    }

    /// <summary>
    /// ExistsFile? || 文件是否存在？
    /// </summary>
    /// <param name="path">FilePath || 文件的路径</param>
    /// <param name="name">FileName || 文件的名称（带后缀名）</param>
    /// <returns>Exists? || 是否存在？</returns>
    public bool ExistsFile(string path, string name)
    {
        FileInfo t = new FileInfo(path + "//" + name);
        return t.Exists == true ? true : false;
    }
}