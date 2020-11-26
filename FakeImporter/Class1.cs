using System;
using System.Collections.Generic;
using Importers;
using Importers.Models;

namespace FakeImporter
{
    public class Class1 : ILodgingImporter
    {
        private string _image = "iVBORw0KGgoAAAANSUhEUgAAAJkAAAD2CAYAAADF/iU1AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAFiUAABYlAUlSJPAAAGFwSURBVHhe7X0FgFVV9/2d7k6YYuju7hZJaQSUkAYBgaFrhhmGBkGRUFQUAwVbbOxCRUQEFAmRbpiu9d/r3DnD4/Hw933/jxEY3tHFfXPvuXH2WWfvfdrIy8uDHXYUJuwks6PQYSeZHYUOO8nsKHTYSWZHocNOMjsKHXaS2VHosJPMjkKHnWR2FDrsJLOj0GEnmR2FDjvJ7Ch02ElmR6HDTrL/Ebm5uQq2rtlhwk6y/wEkV05OjoKdaDeGnWT/H8gFkC2kyszKQlp6ukKW/FZky7OTzRp2kv0XyBXkCIkys7ORkZWJi5cuYcubb+HV11/HufPn5HwWMnOyhYS2779bYSfZf4HcvBxk5Yj2yk==";

        public IEnumerable<LodgingParserModel> Parse(string filePath)
        {
            var lodgingParserModel = new LodgingParserModel
            {
                Name = "",
                TouristPoint = new TouristPointParserModel
                {
                    Id = 0,
                    Categories = new List<string>{"category1"},
                    Image = _image,
                },
                Images = new List<string>{_image},
                
            };
            var lodgingParserModel2 = new LodgingParserModel
            {
                Name = "",
                TouristPoint = new TouristPointParserModel
                {
                    Id = 2,
                    Categories = new List<string>{"category1"},
                    Image = _image
                },
                Images = new List<string>{_image},
            };
            var lodgings = new List<LodgingParserModel>
            {
                lodgingParserModel,
                lodgingParserModel2,
            };
            return lodgings;
        }
    }
}