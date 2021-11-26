using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DeMoMVCNetCore.Models{
    public class TestSearch{
        public List<Category> CateTest { get; set; }
        public SelectList Genres { get; set; }
        public string CateGenre { get; set; }
        public string KeySearch { get; set; }
    }
}