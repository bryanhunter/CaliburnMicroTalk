using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using GameLibrary.Framework;
using GameLibrary.Framework.Results;
using GameLibrary.Model;

namespace GameLibrary.ViewModels
{
    [Export(typeof (AddGameViewModel)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class AddGameViewModel : Screen, IDataErrorInfo
    {
        private readonly IValidator _validator;
        private string _notes;
        private double _rating;
        private string _title;
        private bool _wasSaved;

        [ImportingConstructor]
        public AddGameViewModel(IValidator validator)
        {
            _validator = validator;
        }

        [Required]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
                NotifyOfPropertyChange(() => CanAddGame);
            }
        }

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                NotifyOfPropertyChange(() => Notes);
            }
        }

        public double Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                NotifyOfPropertyChange(() => Rating);
            }
        }

        public bool CanAddGame
        {
            get { return string.IsNullOrEmpty(Error); }
        }

        #region IDataErrorInfo Members

        public string this[string columnName]
        {
            get { return string.Join(Environment.NewLine, _validator.Validate(this, columnName).Select(x => x.Message)); }
        }

        public string Error
        {
            get { return string.Join(Environment.NewLine, _validator.Validate(this).Select(x => x.Message)); }
        }

        #endregion

        public IEnumerable<IResult> AddGame()
        {
            CommandResult add = new AddGameToLibrary
                                    {
                                        Title = Title,
                                        Notes = Notes,
                                        Rating = Rating
                                    }.AsResult();

            _wasSaved = true;

            yield return add;
            yield return Show.Child<SearchViewModel>().In<IShell>();
        }

        public override void CanClose(Action<bool> callback)
        {
            base.CanClose(result =>
                              {
                                  if (!result) callback(false);

                                  //Note: It is not a good practice to call MessageBox.Show from a non-View class.
                                  //Note: Consider implementing a MessageBoxService.
                                  result = _wasSaved || MessageBox.Show(
                                      "Are you sure you want to cancel?  Changes will be lost.",
                                      "Unsaved Changes",
                                      MessageBoxButton.OKCancel
                                                            ) == MessageBoxResult.OK;

                                  callback(result);
                              });
        }
    }
}