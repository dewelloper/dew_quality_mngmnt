using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class CategoryReportsDto
    {
        private string _categoryName = string.Empty;
        public string CategoryName
        {
            get
            {
                return _categoryName;
            }
            set
            {
                _categoryName = value;
            }
        }

        private int _quantity = 0;
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        private int _maxPoint = 0;
        public int MaxPoint
        {
            get
            {
                return _maxPoint;
            }
            set
            {
                _maxPoint = value;
            }
        }

        private double _point = 0;
        public double Point
        {
            get
            {
                return _point;
            }
            set
            {
                _point = value;
            }
        }

        private decimal _percent = 0;
        public decimal Percent
        {
            get
            {
                return _percent;
            }
            set
            {
                _percent = value;
            }
        }

        private string _questionName = string.Empty;

        public string QuestionName
        {
            get
            {
                return _questionName;
            }
            set
            {
                _questionName = value;
            }
        }

        private double _middlePoint = 0;

        public double MiddlePoint
        {
            get
            {
                return _middlePoint;
            }
            set
            {
                _middlePoint = value;
            }
        }
    }
}
