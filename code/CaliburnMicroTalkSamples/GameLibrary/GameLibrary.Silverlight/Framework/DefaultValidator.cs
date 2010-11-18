using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace GameLibrary.Framework
{
    /// <summary>
    /// The default implementation of <see cref="IValidator"/>.
    /// </summary>
    [Export(typeof (IValidator))]
    public class DefaultValidator : IValidator
    {
        #region IValidator Members

        /// <summary>
        /// Indicates whether the specified property should be validated.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns>
        /// true if should be validated; otherwise false
        /// </returns>
        public bool ShouldValidate(PropertyInfo property)
        {
            return property.GetCustomAttributes(true)
                .OfType<ValidationAttribute>()
                .Any();
        }

        /// <summary>
        /// Validates the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>The validation errors.</returns>
        public IEnumerable<IError> Validate(object instance)
        {
            return from property in instance.GetType().GetProperties()
                   from error in GetValidationErrors(instance, property)
                   select error;
        }

        /// <summary>
        /// Validates the specified property on the instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>The validation errors.</returns>
        public IEnumerable<IError> Validate(object instance, string propertyName)
        {
            PropertyInfo property = instance.GetType().GetProperty(propertyName);
            return GetValidationErrors(instance, property);
        }

        #endregion

        private IEnumerable<IError> GetValidationErrors(object instance, PropertyInfo property)
        {
            var context = new ValidationContext(instance, null, null);
            IEnumerable<DefaultError> validators =
                from attribute in property.GetCustomAttributes(true).OfType<ValidationAttribute>()
                where
                    attribute.GetValidationResult(property.GetValue(instance, null), context) !=
                    ValidationResult.Success
                select new DefaultError(
                    instance,
                    property.Name,
                    attribute.FormatErrorMessage(property.Name)
                    );

            return validators.OfType<IError>();
        }
    }
}