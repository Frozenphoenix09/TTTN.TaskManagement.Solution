using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Models.Models.ModuleModels;

namespace TTTN.TaskManagement.Services.Mapper.ModuleMapper
{
    public static class ModuleMapper
    {
        public static ModuleViewModel MapToModel(this Module entity)
        {
            return new ModuleViewModel
            {
                ModuleId = entity.ModuleId,
                ModuleName = entity.ModuleName,
                ModuleActions = entity.ModuleActions,
            };
        }
        public static Module MapToEntity(this ModuleViewModel model)
        {
            return new Module
            {
                ModuleId = model.ModuleId,
                ModuleActions = model.ModuleActions,
                ModuleName = model.ModuleName,
            };
        }
        public static List<Module> MapToEntities (this List<ModuleViewModel> models)
        {
            return models.Select(x => x.MapToEntity()).ToList();
        }
        public static List<ModuleViewModel> MapToModels (this List<Module> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }
    }
}