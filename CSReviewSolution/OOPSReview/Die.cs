using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSReview
{
    //DEFAULT IS PRIVATE
    public class Die
    {

        /*
         * CREATE A CLASS-LEVEL VARIABLE Which will be an instance 
         * of the System namespace math class random
         * 
         * Create a static instance which will be used for ALL Die
         * instances  created by the Developer
         * 
         * This instance of Random will be generated once on the first
         * Die instance that is created
         */
        private static Random _rnd = new Random();


        //Data Members
        //Usually private
        private int _Sides;
        private string _Color;
        //private int _FaceValue;
        
        /*Properties
            Are responsible for assigning and retreiving data to/from
            their associated Data Member

        Retreiving Data from a Data Member uses the "get{}"
        Assigning Data to a Data Member uses the "set{}"
        Properties need to be exposed to outside Users
        Properties will have a return Datatype BUT no parameter list

            Fully implemented property
            Has a defined Data Member that the developer can directly access
        */

        public int Sides
        {
            get
            { //returns Data of a specified Datatype
                return _Sides;
            }
            set
            {  //Assigns a supplied value to the data member
                //The supplied value is located in the key word "value"
                //optionally include data value validation to ensure 
                // an appropriate value has been supplied

                if (value >= 6 && value <= 20)
                {
                    //this is an acceptable value to keep
                    _Sides = value;
                    Roll();
                }
                else
                {
                    //this is an uncaceptable value
                    //issue user friendly error message
                    throw new Exception("Die cannot be " 
                        + value.ToString() + " sided");
                }
            }

        }//public int Side

        //Auto Implemented Property
        /* No Data member definition
         * data member is internally created for you
         * the data member datatype is take from your 
         * return data type -- specified  on the Property  Header
         * Auto implemented properties are usually used  when there is no need to internal validation
         * access to a value managed an auto implemented property
         *  MUST be done via the property
         *  
         *  If you auto implement properties to have validation then a good practice
         *  is to use a private set and have the validation somewhere/how elsewhere
         *  in the class
            
         */
        public int FaceValue { get; private set; }

        public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("You must supply a color string for the die");
                }
                else
                {
                    _Color = value;
                }
            }
        }// public string Color

        //                           CONSTRUCTORS
        /*
         *                           --optional--
         * purpose of a constructor is to ensure that when an instance of this class 
         * is created, it will be created within a stable state; ALWAYS 
         * 
         * you DO NOT call the constructor directly. It is called for you
         * when you create an instance of the class.
         * 
         * if you do not code a constructor, then the system (OS) will asign a default
         * value to each data member/auto implemeted property internal member
         * matching the data type of that item.
         * 
         * if you do code a constructor, then you are responsable for ALL constructors
         * for the class
         * 
         * Have no data type
         * 
         * 
         *   -SYNTAX of a Constructor-
         *   public classname([list of parameters]) { coding block }
         * 
         * 
         *                          -=DEFAULT=-
         * Is Similar to the system default constructor. 
         */
        public Die()
        { /* If you leave this coding block empty it would be 
             the same as using a system default constructor

            optionally, you can set your own default values
           */
            _Sides = 6; //via data member
            Color = "white"; //via property


        }
         /* 
         *                          /-=GREEDY=-
         * This Constructor will allow the user of the class to 
         * pass in a set of values which will be used at the time
         * of instance creation to set the values of the internal
         * data members/auto properties
         */
        public Die(int sides, string color)
        {
            Sides = sides;
            Color = color;
            Roll(); //is an internal method of Die.cs

        }

        /*                      -=BEHAVIOURS=-
         *                        {methods}
         * 
         * Are methods that can be used by the outside user to
         *      a) affect values within the instance
         *      b) use instance data to generate and return info
         */
        public void Roll()
        {
            /* Random can take a set of values and produce a integer value
             * between the two values, where the minimun value is inclusive
             * and the maximun value is exclusive
             */
            FaceValue = _rnd.Next(1, Sides + 1);

        }
    }
}
