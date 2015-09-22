using System.Collections.Generic;
using System.Windows.Forms;

namespace OutlookLimiter
{
    public class ControlHelperCollection
    {

        #region private fields

        private List<Control> _controls; 

        #endregion

        #region protected fields

        #endregion

        #region delegates

        #endregion

        #region events

        #endregion

        #region ctors

        public ControlHelperCollection()
        {
            _controls = new List<Control>();
        }

        #endregion

        #region public properties

        #endregion

        #region interface methods

        #endregion

        #region event handlers

        #endregion

        #region public methods

        public void Enable()
        {
            Enable(true);
        }

        public void Disable()
        {
            Enable(false);
        }

        public void Add(Control c)
        {
            if (!_controls.Contains(c))
            {
                _controls.Add(c);
            }
        }

        #endregion

        #region protected methods

        #endregion

        #region private methods

        private void Enable(bool enable)
        {
            foreach (Control c in _controls)
            {
                c.Enabled = enable;
            }
        }

        #endregion

        #region helper methods

        #endregion

    }
}