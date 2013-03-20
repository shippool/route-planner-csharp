﻿using System;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace ESRI.ArcLogistics.DomainObjects.Validation
{
    class CapacityValidatorAttribute : ValidatorAttribute
    {
        #region Constructors
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        public CapacityValidatorAttribute() {}

        public CapacityValidatorAttribute(int capIndex)
        {
            _capacityIndex = capIndex;
        }
        #endregion // Constructors

        #region Protected methods
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        protected override Validator DoCreateValidator(Type targetType)
        {
            return new CapacityValidator(_capacityIndex);
        }
        #endregion // Protected methods

        #region Private members
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        private int? _capacityIndex = null;
        #endregion // Private members
    }
}
