using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using GameLibrary.Framework;
using GameLibrary.Model;
using GameLibrary.Views;

namespace GameLibrary
{
    public class MefBootstrapper : Bootstrapper<IShell>
    {
        private CompositionContainer container;

        public MefBootstrapper()
        {
            LogManager.GetLog = type => new DebugLog(type);

            Func<Type, DependencyObject, object, UIElement> locateView = ViewLocator.LocateForModelType;

            // Keep our View to View convention, but add special case for GameDTO
            ViewLocator.LocateForModelType = (modelType, displayLocation, context) =>
                                                 {
                                                     return modelType.Equals(typeof (GameDTO)) 
                                                         ? new GameView() 
                                                         : locateView(modelType, displayLocation, context);
                                                 };

            // Add a new element binding convention for the Rating control
            ConventionManager.AddElementConvention<Rating>(Rating.ValueProperty, "Value", "ValueChanged");
        }


        protected override void Configure()
        {
            container = CompositionHost.Initialize(
                new AggregateCatalog(
                    AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()
                    )
                );

            var batch = new CompositionBatch();
            batch.AddExportedValue(container);
            batch.AddExportedValue<IWindowManager>(new WindowManager());
            container.Compose(batch);
        }


        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            IEnumerable<object> exports = container.GetExportedValues<object>(contract);

            if (exports.Count() > 0)
                return exports.First();

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override void BuildUp(object instance)
        {
            container.SatisfyImportsOnce(instance);
        }
    }
}