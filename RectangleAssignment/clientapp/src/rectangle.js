import React, { useEffect, useState } from 'react';
import { ResizableBox } from 'react-resizable';
import 'react-resizable/css/styles.css';
import './App.css'; 

const Rectangle = ({ dimensions, onResize }) => {
    //
    const [rectDimensions, setRectDimensions] = useState(dimensions);
    const [position, setPosition] = useState({ x: 0, y: 0 });

    useEffect(() => {
        if (dimensions && dimensions.width > 0 && dimensions.height > 0) {
            setRectDimensions(dimensions);
            setPosition({
                x: (500 - dimensions.width) / 2,
                y: (500 - dimensions.height) / 2,
            });
        }
    }, [dimensions]);

    const handleResize = ({ size }) => {
        if (size && size.width > 0 && size.height > 0) { 
            setRectDimensions(size);
            setPosition({
                x: (500 - size.width) / 2,
                y: (500 - size.height) / 2,
            });
        }
    };

    const handleResizeStop = (event, { size }) => {
        if(size && size.width > 0 && size.height > 0){
            onResize(size);
        }
    };
    return (
        <div style={{ position: 'relative', width: '500px', height: '500px', border: '1px solid #ccc' }}>
            <ResizableBox
                width={rectDimensions.width}
                height={rectDimensions.height}
                minConstraints={[10, 10]}
                maxConstraints={[500, 500]}
                resizeHandles={['se', 'sw', 'ne', 'nw', 'n', 's', 'e', 'w']}
                onResize={handleResize}
                onResizeStop={handleResizeStop}
                className='rectangle-box'
                style={{
                    left: position.x,
                    top: position.y,
                }}
            />
        </div>
    );
};

export default Rectangle;
