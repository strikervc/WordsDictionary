using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WordsDictionary.Models
{
    public class Pronunciation
    {
        public string Word { get; set; }
        public PronunciationObject Pronunciations { get; set; }
        
    }

    public class PronunciationObject
    {
        public string All { get; set; }


    }


}

