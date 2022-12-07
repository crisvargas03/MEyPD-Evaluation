import React from "react";

const Navbar = ({ UserName }) => (
  <div className="d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-white border-bottom shadow-sm">
    <h4 className="my-0 mr-md-auto font-weight-normal">School App</h4>
    <nav className="my-2 my-md-0 mr-md-3">
      <a href="/Home" className="p-2 text-dark">
        {UserName ? UserName : ""}
      </a>
    </nav>
    <a href="/" className="btn btn-outline-dark">
      Cerrar Sesion
    </a>
  </div>
);

export default Navbar;
