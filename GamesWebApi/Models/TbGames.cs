﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GamesWebApi.Models
{
    public partial class TbGames
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Deskripsi { get; set; }
        public int? Idgenre { get; set; }
        public string Rilistahun { get; set; }
        public int? Idplatform { get; set; }
        public string Pembuat { get; set; }
        public DateTime? Tglinput { get; set; }
        public byte? Status { get; set; }

        public virtual TbGenre IdgenreNavigation { get; set; }
        public virtual TbPlatform IdplatformNavigation { get; set; }
    }
}