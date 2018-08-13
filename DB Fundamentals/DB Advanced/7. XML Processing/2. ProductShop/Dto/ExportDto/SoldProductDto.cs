﻿namespace ProductShop.Dto.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("product")]
    public class SoldProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}