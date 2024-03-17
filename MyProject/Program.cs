﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

static class Program
{ 
    static void Main()
    {
        foreach (string match in Search("c:\\", "*.xml"))
        {
            Console.WriteLine(match);
        }
    }
    static IEnumerable<string> Search(string root, string searchPattern)
    {
        Queue<string> dirs = new Queue<string>();
        dirs.Enqueue(root);
        while (dirs.Count > 0)
        {
            string dir = dirs.Dequeue();

            string[] paths = null;
            try
            {
                paths = Directory.GetFiles(dir, searchPattern);
            }
            catch { }

            if (paths != null && paths.Length > 0)
            {
                foreach (string file in paths)
                {
                    yield return file;
                }
            }

            paths = null;
            try
            {
                paths = Directory.GetDirectories(dir);
            }
            catch { }

            if (paths != null && paths.Length > 0)
            {
                foreach (string subDir in paths)
                {
                    dirs.Enqueue(subDir);
                }
            }
        }
    }
}