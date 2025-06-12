using PAW.Models.PAWModels;
using PAW.Architecture.Extensions;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PAW.MinimalApi.Factory;

public interface ICatalogFactory
{
    void ApplyAuditing(IEntity entity, string user, bool isInserting);
    IEntity CreateEntity<T>() where T : class, new();
    IEntity CreateEntity<T>(string name) where T : class, new();
}

public abstract class CatalogFactory : ICatalogFactory
{
    public virtual IEntity CreateEntity<T>() where T : class, new()
    {
        var entity = Activator.CreateInstance(typeof(T));
        return entity as IEntity;
        //return new T() as IEntity;
    }

    public virtual IEntity CreateEntity<T>(string name) where T : class, new()
    {
        var entity = Activator.CreateInstance(typeof(T)) as IEntity;
        entity.TempID = 123456;//new DateTime().GenerateIdFromNow();
        return entity;
    }

    public virtual void ApplyAuditing(IEntity entity, string user, bool isInserting)
    {
        Action<IEntity, string> funcWhenInserting = new((entity, user) =>
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = user;
        });

        Action<IEntity, string> funcWhenUpdating = new((entity, user) =>
        {
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = user;
        });

        Action<IEntity, string, bool> funcApply = new((entity, user, inserting) =>
        {
            if (isInserting)
                funcWhenInserting(entity, user);
            else
                funcWhenUpdating(entity, user);
        });

        funcApply(entity, user, isInserting);
    }
}
