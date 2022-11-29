import React from "react";
import notfound from "../Assets/images/notfound.png";

const NotFound = () => {
  return (
    <div className="notfound-page">
      <h1>Pagina no encontrada, lo sentimos...</h1>
      <img src={notfound} className="img" alt="404-page" />
    </div>
  );
};

export default NotFound;
