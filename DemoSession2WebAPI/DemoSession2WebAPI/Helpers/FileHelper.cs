﻿namespace DemoSession2WebAPI.Helpers;

public class FileHelper
{
    public static string generateFileName(string fileName)
    {
        var name = Guid.NewGuid().ToString().Replace("-", "");
        // a.doc.gig.jpg.png
        var lastIndex = fileName.LastIndexOf('.');
        var ext = fileName.Substring(lastIndex);
        return name + ext;
    }
}
