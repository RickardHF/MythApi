namespace MythApi.Common.Interfaces;

public interface IGet<TModel, TParameter> {
    public Task<TModel> GetAsync(TParameter parameter);
}