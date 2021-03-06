﻿using System;
using Bytes2you.Validation;
using PetsWonderland.Client.NinjectFactories.Contracts;
using WebFormsMvp;
using WebFormsMvp.Binder;

namespace PetsWonderland.Client.NinjectFactories
{
    public class NinjectPresenterFactory : IPresenterFactory
    {
        private readonly INinjectPresenterFactory presenterFactory;

        public NinjectPresenterFactory(INinjectPresenterFactory presenterFactory)
        {
            Guard.WhenArgument(presenterFactory, "An instance of presenter factory is required").IsNull().Throw();

            this.presenterFactory = presenterFactory;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            Guard.WhenArgument(presenterType, "Presenter type is required!").IsNull().Throw();
            Guard.WhenArgument(viewType, "View type is required!").IsNull().Throw();
            Guard.WhenArgument(viewInstance, "View instance is required!").IsNull().Throw();

            var presenter = this.presenterFactory.GetPresenter(presenterType, viewType, viewInstance);
            return presenter;
        }

        public void Release(IPresenter presenter)
        {
            var disposable = presenter as IDisposable;

            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}