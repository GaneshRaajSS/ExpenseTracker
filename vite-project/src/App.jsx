
import './App.css'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import LandingPage from './components/LandingPage/landingPage'
import SignInPage from './components/SignInPage/Signin_Page';
import Dashboard from './components/UserComponent/DashboardPage/Dashboard';

function App() {
  
  return (
    <>
    <Router>
    <Routes>
      <Route path="/" element={<LandingPage />} />
      <Route path="/signin" element={<SignInPage />}/>
      <Route path="/Dashboard" element={<Dashboard />}/>
    </Routes>
    </Router>
    
      
    </>
  )
}

export default App
