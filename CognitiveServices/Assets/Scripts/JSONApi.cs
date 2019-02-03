using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONApi : MonoBehaviour
{
    public List<Category> categories { get; set; }
    public string requestId { get; set; }
    public Metadata metadata { get; set; }

    public class Landmark
    {
        public string name { get; set; }
        public double confidence { get; set; }
    }

    public class Detail
    {
        public List<Landmark> landmarks { get; set; }
    }

    public class Category
    {
        public string name { get; set; }
        public double score { get; set; }
        public Detail detail { get; set; }
    }

    public class Metadata
    {
        public int width { get; set; }
        public int height { get; set; }
        public string format { get; set; }
    }

}
