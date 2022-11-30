import React from "react";
import ServiceCards from "./ServiceCards";

export const Welcome = () => {
  return (
    <div className="pricing-header px-3 py-3 pt-md-5 pd-md-4 mx-auto text-center">
      <h1 className="display-4">Bienvenido</h1>
      <div className="lead">
        <p>
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Nihil ullam,
          impedit quia excepturi ad sunt eaque dolores odio tenetur molestiae
          nobis fugiat beatae ducimus quisquam culpa optio! Reprehenderit, id
          aspernatur.
        </p>
      </div>
      <div className="container">
        <ServiceCards />
      </div>
    </div>
  );
};
