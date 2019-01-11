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
        //Data Members
        //Usually private
        private int _Side;
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

        public int Side
        {
            get
            { //returns Data of a specified Datatype
                return _Side;
            }
            set
            {  //Assigns a supplied value to the data member
                //The supplied value is located in the key word "value"
                //optionally include data value validation to ensure 
                // an appropriate value has been supplied

                if (value >= 6 && value <= 20)
                {
                    //this is an acceptable value to keep
                    _Side = value;
                }
                else
                {
                    //this is an uncaceptable value
                    //issue user friendly error message
                    throw new Exception("Die cannot be " 
                        + value.ToString() + " sided");
                }
                
            }

        }//Side

        //Auto Implemented Property
        /* No Data member definition
         * data member is internally created for you
         * the data member datatype is take from your 
         * return data type -- specified  on the Property  Header
         * Auto implemented properties are usually used  when there is no need to internal validation
         * access to a value managed an auto implemented property
         *  MUST be done via the property
            
         */
         public int Facevalue { get; set; }
    }
}
