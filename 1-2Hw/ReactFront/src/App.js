
import './App.css';
import React from "react";
import Dogs from './components/Dogs';
import Description from './components/Description';
import { Route, Routes } from 'react-router-dom';

function App() {

  return (
    <div>
      <Routes>
        <Route path='/' element={< Dogs/>} />
        <Route path='/:id' element={<Description />}/>
    </Routes>
    </div>
  );
}

export default App;
