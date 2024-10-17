import React, { useState } from 'react';
import Rectangle from './rectangle';
import axios from 'axios';
import { useMutation } from '@tanstack/react-query';
import './App.css'; 


const postDimensions = async ({newDimensions, perimeter}) => {
    console.log("Posting dimensions:", newDimensions);
    const requestBody = {
        Width: newDimensions.width,
        Height: newDimensions.height,
        Perimeter: perimeter
      
      };
    await axios.post('https://localhost:7292/api/v1/rectangle-dimensions', requestBody, {
        headers: {
            'Content-Type': 'application/json',
        },
    });
};

const App = () => {
    const [dimensions, setDimensions] = useState(null);
    const [perimeter, setPerimeter] = useState(0);

    const mutation = useMutation({
        mutationFn: postDimensions,
        onError: (error) => {
            console.error('Error posting dimensions:', error);
            alert(`Error updating dimensions: ${error.response?.data.message || error.message}`);
        },
        onSuccess: () => {
            console.log('Dimensions updated successfully');
        },
    });

    const fetchDimensions = async () => {
        try {
            const response = await axios.get('https://localhost:7292/api/v1/rectangle-dimensions');
            console.log('Fetched dimensions:', response.data);
            const newPerimeter = 2 * (response.data.width + response.data.height);
            setDimensions(response.data);
            setPerimeter(newPerimeter);
        } catch (error) {
            console.error('Error fetching dimensions:', error);
            alert(`Error fetching dimensions: ${error.response?.data.message || error.message}`);

        }
    };

    const updateDimensions = (newDimensions) => {
      if(newDimensions && newDimensions.width > 0 && newDimensions.height > 0){
        setDimensions(newDimensions);
        const newPerimeter = 2 * (newDimensions.width + newDimensions.height);
        setPerimeter(newPerimeter);
        
        mutation.mutate({newDimensions, perimeter});
      }
    };

    return (
      <div className='app-container'>
          <div>
              <h1>SVG Rectangle Drawer</h1>
              <button onClick={fetchDimensions} style={{ marginBottom: '10px' }}>
                  Fetch Initial Dimensions
              </button>
              {dimensions ? (
                  <>
                      <Rectangle dimensions={dimensions} onResize={updateDimensions} />
                      <div>
                      <p>Perimeter: {perimeter !== null ? perimeter : "Calculating..."}</p>
                      </div>
                  </>
              ) : (
                  <p>Please click the button to load dimensions.</p>
              )}
          </div>
      </div>
  );
};

export default App;
