namespace MythApi.Common.Interfaces;

public interface IPost<TModel, TParameter, TBody> {
    public Task<TModel> PostAsync(TParameter parameter, TBody body);
}