using System;
using System.Reflection;
using UnityEngine;
using UnityMvvmToolkit.Core;
using UnityMvvmToolkit.Core.Enums;
using UnityMvvmToolkit.Core.Interfaces;

[GenerateMVVMBinding]
public partial class TestBindable : MonoBehaviour, IObjectProvider
{
    public IObjectProvider WarmupAssemblyViewModels()
    {
        throw new NotImplementedException();
    }

    public IObjectProvider WarmupAssemblyViewModels(Assembly assembly)
    {
        throw new NotImplementedException();
    }

    public IObjectProvider WarmupViewModel<TBindingContext>() where TBindingContext : IBindingContext
    {
        throw new NotImplementedException();
    }

    public IObjectProvider WarmupViewModel(Type bindingContextType)
    {
        throw new NotImplementedException();
    }

    public IObjectProvider WarmupValueConverter<T>(int capacity, WarmupType warmupType = WarmupType.OnlyByType) where T : IValueConverter
    {
        throw new NotImplementedException();
    }

    public IProperty<TValueType> RentProperty<TValueType>(IBindingContext context, PropertyBindingData bindingData)
    {
        throw new NotImplementedException();
    }

    public void ReturnProperty<TValueType>(IProperty<TValueType> property)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyProperty<TValueType> RentReadOnlyProperty<TValueType>(IBindingContext context, PropertyBindingData bindingData)
    {
        throw new NotImplementedException();
    }

    public void ReturnReadOnlyProperty<TValueType>(IReadOnlyProperty<TValueType> property)
    {
        throw new NotImplementedException();
    }

    public TCommand GetCommand<TCommand>(IBindingContext context, string propertyName) where TCommand : IBaseCommand
    {
        throw new NotImplementedException();
    }

    public IBaseCommand RentCommandWrapper(IBindingContext context, CommandBindingData bindingData)
    {
        throw new NotImplementedException();
    }

    public void ReturnCommandWrapper(IBaseCommand command, CommandBindingData bindingData)
    {
        throw new NotImplementedException();
    }

    public TValue GetCollectionItemTemplate<TKey, TValue>()
    {
        throw new NotImplementedException();
    }
}