import { useState } from 'react';

export function Alert({ type, heading, children, closable, onClose }) {
  const [visible, setVisible] = useState(true);

  if (!visible) {
    return null;
  }

  function handleCloseClick() {
    setVisible(false);
    if (onClose) {
      onClose();
    }
  }

  return (
    <div>
      <div>
        <span role="img" aria-label={type === 'warning' ? 'warning' : 'information'}>
          {type === 'warning' ? '⚠️' : 'ℹ️'}
        </span>
        <span>{heading}</span>
      </div>
      {closable && (
        <button aria-label="Close" onClick={handleCloseClick}>
          <span role="img" aria-label="Close">
            ❌
          </span>
        </button>
      )}
      <div>{children}</div>
    </div>
  );
}
