﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using ESRI.ArcLogistics.App.OrderSymbology;

namespace ESRI.ArcLogistics.App.Controls
{
    /// <summary>
    /// Control container for Symbol ControlTemplate
    /// </summary>
    internal class SymbolBox : Control
    {
        #region constructors

        public SymbolBox(string templateFileName)
        {
            _SetTemplate(templateFileName);
            _dataContext = new SymbologyContext();
            DataContext = _dataContext;
            HorizontalContentAlignment = HorizontalAlignment.Center;
        }

        public SymbolBox()
        {
            _templateFileName = SymbologyManager.DEFAULT_TEMPLATE_NAME;
            Template = SymbologyManager.DefaultTemplate;
            _dataContext = new SymbologyContext();
            DataContext = _dataContext;
            HorizontalContentAlignment = HorizontalAlignment.Center;
        }
        
        #endregion

        #region public members

        /// <summary>
        /// Size of symbol
        /// </summary>
        public int Size
        {
            get
            {
                return (int)_dataContext.Attributes[SymbologyContext.SIZE_ATTRIBUTE_NAME];
            }
            set
            {
                ControlTemplate ct = Template;
                Template = null;
                _dataContext.Attributes[SymbologyContext.SIZE_ATTRIBUTE_NAME] = value;
                _dataContext.Attributes[SymbologyContext.FULLSIZE_ATTRIBUTE_NAME] = value + SymbologyManager.DEFAULT_INDENT;
                Template = ct;
            }
        }

        /// <summary>
        /// Color of Symbol
        /// </summary>
        public SolidColorBrush Fill
        {
            get
            {
                return (SolidColorBrush)_dataContext.Attributes[SymbologyContext.FILL_ATTRIBUTE_NAME];
            }
            set
            {
                ControlTemplate ct = Template;
                Template = null;
                _dataContext.Attributes[SymbologyContext.FILL_ATTRIBUTE_NAME] = value;
                Template = ct;
            }
        }

        /// <summary>
        /// FileName of ControlTemplate
        /// </summary>
        public string TemplateFileName
        {
            get { return _templateFileName; }
            set 
            {
                _SetTemplate(value); 
            }
        }

        public SymbologyRecord ParentRecord
        { get; set; }
        
        #endregion

        #region private methods

        /// <summary>
        /// Set ControlTemplate to control
        /// </summary>
        /// <param name="templateFileName">Filename of ControlTemplate</param>
        private void _SetTemplate(string templateFileName)
        {
            int templateIndex = SymbologyManager.TemplatesFileNames.IndexOf(templateFileName);
            if (templateIndex == -1)
            {
                _templateFileName = SymbologyManager.DEFAULT_TEMPLATE_NAME;
                Template = SymbologyManager.DefaultTemplate;
            }
            else
            {
                _templateFileName = templateFileName;
                Template = SymbologyManager.Templates[templateIndex];
            }
        }
        
        #endregion

        #region private members

        private SymbologyContext _dataContext;
        private string _templateFileName;

        #endregion
    }
}