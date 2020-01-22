/*-----------------------------------------------------------------------------
    Author     Erik Smith
    Created    2020-01-21
    Purpose    This class represents a custom mutable data structure that is
               designed to be used as an accumlator while building the aged 
               dataset. 
-------------------------------------------------------------------------------
    Modification History
  
    01/21/2020  Erik W. Smith
    [1:eof]
        Initial development.
-----------------------------------------------------------------------------*/
namespace universalAgingTool
{
    public class AgedDataStore
    {
        // fields represent each 'bucket' in the aging schedule
        public float Day0To30    { get; private set; }
        public float Day31To60   { get; private set; }
        public float Day61To90   { get; private set; }
        public float Day91To120  { get; private set; }
        public float Day121To150 { get; private set; }
        public float Day151To180 { get; private set; }
        public float Day181To270 { get; private set; }
        public float Day271To360 { get; private set; }
        public float Day361Plus  { get; private set; }

        public AgedDataStore()
        {
            // explicitly setting an empty structure to 0 to avoid runtime errors.
            Zero();
        }

        public void Zero()
        {
            this.Day0To30    = 0; // bucket 0
            this.Day31To60   = 0; // bucket 1
            this.Day61To90   = 0; // bucket 2
            this.Day91To120  = 0; // bucket 3
            this.Day121To150 = 0; // bucket 4
            this.Day151To180 = 0; // bucket 5
            this.Day181To270 = 0; // bucket 6
            this.Day271To360 = 0; // bucket 7
            this.Day361Plus  = 0; // bucket default
        }

        public void AddAgedData(int bucket, float value)
        {
            switch (bucket)
            {
                case 0:
                    this.Day0To30    += value;
                    break;
                case 1:
                    this.Day31To60   += value;
                    break;
                case 2:
                    this.Day61To90   += value;
                    break;
                case 3:
                    this.Day91To120  += value;
                    break;
                case 4:
                    this.Day121To150 += value;
                    break;
                case 5:
                    this.Day151To180 += value;
                    break;
                case 6:
                    this.Day181To270 += value;
                    break;
                case 7:
                    this.Day271To360 += value;
                    break;
                default:
                    if (bucket >= 8)
                    {
                        this.Day361Plus += value;
                        break;
                    }
                    else
                    {
                        break;
                    }
            }
        }

    }
}
