using DataAccess.Entities;

namespace DataAccess;

public static class EntityExtensions
{
    public static TModel MapTo<TModel>(this IEntity entity)
    {
        if (entity == null) 
            throw new ArgumentNullException(nameof(entity));
        
        var model = Activator.CreateInstance<TModel>()!;
        var modelProps = model.GetType().GetProperties();
        var entityProps = entity.GetType().GetProperties().Where(p => p.Name != "Id").ToArray();

        for (var i = 0; i < modelProps.Length; i++)
        {
            modelProps[i].SetValue(model, entityProps[i].GetValue(entity));
        }

        return model;
    }
}