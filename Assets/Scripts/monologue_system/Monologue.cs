using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;



[XmlRoot("monologue")]
public class Monologue
{
    [XmlElement("node")] 
    public MainRootNode[] nodes;

  
    [System.Serializable]
    public class MainRootNode
    {
        [XmlElement("npctext")]
        public String Npctext;
    }
}