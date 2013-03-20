﻿using System;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace ESRI.ArcLogistics.DomainObjects.Validation
{
    [ConfigurationElementType(typeof(CustomValidatorData))]
    class CapacityValidator : Validator<Capacities>
    {
        #region Constructors
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        public CapacityValidator(int? capIndex)
            : base(null, null)
        {
            _capacityIndex = capIndex;
        }
        #endregion // Constructors

        #region Public methods
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        protected override void DoValidate(Capacities objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            if (_capacityIndex == null)
            {   // validate whole object
                for (int i = 0; i < objectToValidate.Count; i++)
                    _ValidateCapacity(objectToValidate, i, currentTarget, key, validationResults);
            }
            else
                _ValidateCapacity(objectToValidate, _capacityIndex.Value, currentTarget, key, validationResults);
        }

        protected override string DefaultMessageTemplate
        {
            get { return Properties.Messages.Error_InvalidCapacity; }
        }
        #endregion // Public methods

        #region Private methods
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        private void _ValidateCapacity(Capacities capacities, int index, object currentTarget, string key, ValidationResults validationResults)
        {
            if (capacities[index] < 0)
            {
                string message = string.Format(this.MessageTemplate, capacities.Info[index].Name);
                this.LogValidationResult(validationResults, message, currentTarget, key);
            }
        }
        #endregion // Private methods

        #region Private members
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        private int? _capacityIndex = null;
        #endregion // Private members
    }
}
