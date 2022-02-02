﻿

namespace PirzzaApi.Core.Dtos
{
    public class PizzaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IngredientDto> Ingredients { get; set; }
    }
}
