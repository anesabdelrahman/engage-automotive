using System.Text.Json;
using AutomotivePartsOrdering.Service.Dto;

namespace AutomotivePartsOrdering.Service.Application
{
    public class StubbedDataLoaderService
    {
        public static async Task<PartDto> LoadStubbedPartDataAsync(string brandCode, string partCode) {
            var filePath = "Stubbed Data\\Parts.txt";

            var jsonData = await File.ReadAllTextAsync(filePath);
            var parts = JsonSerializer.Deserialize<List<PartDto>>(jsonData);

            if (parts == null) {
                return new PartDto();
            }

            var filteredPart = parts
                .Where(p => p.BrandCode == brandCode && p.PartCode == partCode)
                .Select(p => new PartDto {
                    Id = p.Id,
                    BrandCode = p.BrandCode,
                    PartCode = p.PartCode,
                    Description = p.Description,
                    Quantity = p.Quantity,
                    Price = p.Price
                })
                .FirstOrDefault();

            return filteredPart ?? new PartDto();
        }

        public static async Task<BrandsDto?> LoadStubbedBrandDataAsync()
        {
            var filePath = "Stubbed Data\\Brands.txt";

            var jsonData = await File.ReadAllTextAsync(filePath);
            var brands = JsonSerializer.Deserialize<BrandsDto>(jsonData, new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true 
            });

            return brands ?? new BrandsDto();
        }
    }
}