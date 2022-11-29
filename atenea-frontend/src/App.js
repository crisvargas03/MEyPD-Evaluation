import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "./Pages/Login/Login";
import HomePage from "./Pages/Home/HomePage";
import NotFound from "./Pages/NotFound";
import { StudentList } from "./Pages/Students/StudentList";

const App = () => {
  return (
    <div className="fluid-container">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="/Home" element={<HomePage />} />
          <Route path="/Students" element={<StudentList />} />

          <Route path="*" element={<NotFound />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
};

export default App;
