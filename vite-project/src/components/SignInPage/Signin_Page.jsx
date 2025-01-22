import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import { jwtDecode } from 'jwt-decode';
import Cookies from 'js-cookie';

const SignInPage = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [isLoading, setIsLoading] = useState(false);
  const navigate = useNavigate();
  const [showPassword, setShowPassword] = useState(false);

  const handleLogoClick = (e) => {
    e.preventDefault();
    navigate('/');
  };

  const handleLogin = async (e) => {
    e.preventDefault();
    setIsLoading(true);
    setError('');

    const loginData = {
      email: email.trim(),
      password: password,
    };

    try {
      const response = await axios.post('https://localhost:7035/api/Auth', loginData);
      
      // Check if response.data exists and contains token
      if (!response?.data?.token) {
        throw new Error('No token received from server');
      }

      const { token } = response.data;
      
      // Validate token before storing
      const decodedToken = jwtDecode(token);
      
      if (!decodedToken?.role) {
        throw new Error('Invalid token structure: missing role');
      }

      // Store token and role
      Cookies.set('token', token, { secure: true, sameSite: 'strict' });
      Cookies.set('role', decodedToken.role, { secure: true, sameSite: 'strict' });

      // Navigate based on role
      navigate(decodedToken.role === 'SuperAdmin' ? '/admin' : '/Dashboard');

    } catch (err) {
      console.error('Login error:', err);
      setError(
        err.response?.data?.message || 
        err.message || 
        'An error occurred during sign in'
      );
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="min-h-screen flex bg-white">
      <div 
        className="hidden lg:flex lg:w-1/2 h-400 bg-cover bg-center" 
        style={{ backgroundImage: "url(https://cdn.mos.cms.futurecdn.net/5fz9SMYxWbv44jFVcD4vmd.jpg)" }}
      />

      <div className="w-full lg:w-1/2 flex flex-col justify-center px-4 sm:px-6 lg:px-8 h-1/2">
        <div className="flex items-start justify-start mt-4 mb-8">
          <img
            src="/Images/HEXA_HUB.png"
            alt="HexaHub Logo"
            className="h-20 w-20 mr-4 cursor-pointer" 
            onClick={handleLogoClick}
          />
        </div>
        
        <div className="w-full max-w-md mx-auto">
          <h2 className="mt-6 text-center text-2xl font-extrabold text-indigo-950">
            Welcome Back!
          </h2>

          <div className="mt-8 bg-white py-8 px-4 shadow sm:rounded-lg sm:px-10">
            <form className="space-y-4" onSubmit={handleLogin}>
              <input
                className="text-black bg-white w-full px-3 py-2 border border-gray-300 rounded-md"
                type="email"
                placeholder="Email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                required
              />
              
              <div className="relative">
                <input
                  className="text-black bg-white w-full px-3 py-2 border border-gray-300 rounded-md"
                  type={showPassword ? 'text' : 'password'}
                  placeholder="Password"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                  required
                  minLength={6}
                />
                <button
                  type="button"
                  className="bg-transparent absolute inset-y-0 right-0 pr-3 flex items-center focus:outline-none"
                  onClick={() => setShowPassword(!showPassword)}
                  aria-label={showPassword ? 'Hide password' : 'Show password'}
                >
                  {showPassword ? '👁️' : '👁️‍🗨️'}
                </button>
              </div>

              <button
                type="submit"
                className="w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-cyan-500 hover:bg-indigo-950 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-cyan-500 disabled:opacity-50"
                disabled={isLoading}
              >
                {isLoading ? 'Signing In...' : 'Sign In'}
              </button>
            </form>

            {error && (
              <div className="text-red-500 text-sm mt-4 text-center">{error}</div>
            )}

            <div className="mt-6 flex items-center justify-between text-sm">
              <a href="/Privacy" className="font-medium text-indigo-950 hover:text-cyan-500">Privacy</a>
              <a href="/Terms" className="font-medium text-indigo-950 hover:text-cyan-500">Terms</a>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default SignInPage;