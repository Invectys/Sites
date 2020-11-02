



function ConfettiConfigure(wrapper, name) {
    
    var Object = {
        maxCount: 150,      //set max Object count
        speed: 2,           //set the particle animation speed
        frameInterval: 15,  //the Object animation frame interval
        alpha: 1.0,         //the alpha opacity of the Object (between 0 and 1, where 1 is opaque and 0 is invisible)
        gradient: false,    //whether to use gradients for the Object particles
        start: null,        //call to start Object animation
        stop: null,         //call to stop adding Object
        toggle: null,       //call to start or stop the Object animation depending on whether it's already running
        pause: null,        //call to freeze Object animation
        resume: null,       //call to unfreeze Object animation
        togglePause: null,  //call to toggle whether the Object animation is paused
        remove: null,       //call to stop the Object animation and remove all Object immediately
        isPaused: null,     //call and returns true or false depending on whether the Object animation is paused
        isRunning: null,   //call and returns true or false depending on whether the animation is running
        name: null,
        type: "confetti"
    };
    wrapper.ref = Object;
   
	Object.start = startObject;
    Object.stop = stopObject;
    Object.attach = AttachToBlock;
	Object.toggle = toggleObject;
	Object.pause = pauseObject;
	Object.resume = resumeObject;
	Object.togglePause = toggleObjectPause;
	Object.isPaused = isObjectPaused;
	Object.remove = removeObject;
    Object.isRunning = isObjectRunning;

    var Name = "Object-canvas_" + name;
    Object.name = Name;
    


	var supportsAnimationFrame = window.requestAnimationFrame || window.webkitRequestAnimationFrame || window.mozRequestAnimationFrame || window.oRequestAnimationFrame || window.msRequestAnimationFrame;
	var colors = ["rgba(30,144,255,", "rgba(107,142,35,", "rgba(255,215,0,", "rgba(255,192,203,", "rgba(106,90,205,", "rgba(173,216,230,", "rgba(238,130,238,", "rgba(152,251,152,", "rgba(70,130,180,", "rgba(244,164,96,", "rgba(210,105,30,", "rgba(220,20,60,"];
	var streamingObject = false;
	var animationTimer = null;
	var pause = false;
	var lastFrameTime = Date.now();
	var particles = [];
	var waveAngle = 0;
	var context = null;

    function AttachToBlock($block) {
        $("#" + Name).appendTo($block);
    }

	function resetParticle(particle, width, height) {
		particle.color = colors[(Math.random() * colors.length) | 0] + (Object.alpha + ")");
		particle.color2 = colors[(Math.random() * colors.length) | 0] + (Object.alpha + ")");
		particle.x = Math.random() * width;
		particle.y = Math.random() * height - height;
		particle.diameter = Math.random() * 10 + 5;
		particle.tilt = Math.random() * 10 - 10;
		particle.tiltAngleIncrement = Math.random() * 0.07 + 0.05;
		particle.tiltAngle = 0;
		return particle;
	}

	function toggleObjectPause() {
		if (pause)
			resumeObject();
		else
			pauseObject();
	}

	function isObjectPaused() {
		return pause;
	}

	function pauseObject() {
		pause = true;
	}

	function resumeObject() {
		pause = false;
		runAnimation();
	}

	function runAnimation() {
		if (pause)
			return;
		if (particles.length === 0) {
			context.clearRect(0, 0, window.innerWidth, window.innerHeight);
			animationTimer = null;
		} else {
			var now = Date.now();
			var delta = now - lastFrameTime;
			if (!supportsAnimationFrame || delta > Object.frameInterval) {
				context.clearRect(0, 0, window.innerWidth, window.innerHeight);
				updateParticles();
				drawParticles(context);
				lastFrameTime = now - (delta % Object.frameInterval);
			}
			animationTimer = requestAnimationFrame(runAnimation);
		}
	}

	function startObject() {
		var width = window.innerWidth;
		var height = window.innerHeight;
		window.requestAnimationFrame = (function() {
			return window.requestAnimationFrame ||
				window.webkitRequestAnimationFrame ||
				window.mozRequestAnimationFrame ||
				window.oRequestAnimationFrame ||
				window.msRequestAnimationFrame ||
				function (callback) {
					return window.setTimeout(callback, Object.frameInterval);
				};
        })();

        var canvas = document.getElementById(Object.name);
		if (canvas === null) {
			canvas = document.createElement("canvas");
            canvas.setAttribute("id", Object.name);
            canvas.classList.add("Object");
			canvas.setAttribute("style", "display:block;z-index:999999;pointer-events:none");
			document.body.appendChild(canvas);
			canvas.width = width;
			canvas.height = height;
			window.addEventListener("resize", function() {
				canvas.width = window.innerWidth;
				canvas.height = window.innerHeight;
			}, true);
			context = canvas.getContext("2d");
		}
		while (particles.length < Object.maxCount)
			particles.push(resetParticle({}, width, height));
		streamingObject = true;
		pause = false;
		runAnimation();
	}

	function stopObject() {
		streamingObject = false;
	}

	function removeObject() {
		stop();
		pause = false;
		particles = [];
	}

	function toggleObject() {
		if (streamingObject)
			stopObject();
		else
			startObject();
	}
	
	function isObjectRunning() {
		return streamingObject;
	}

    


	function drawParticles(context) {
		var particle;
		var x, y, x2, y2;
		for (var i = 0; i < particles.length; i++) {
			particle = particles[i];
			context.beginPath();
			context.lineWidth = particle.diameter;
			x2 = particle.x + particle.tilt;
			x = x2 + particle.diameter / 2;
			y2 = particle.y + particle.tilt + particle.diameter / 2;
			if (Object.gradient) {
				var gradient = context.createLinearGradient(x, particle.y, x2, y2);
				gradient.addColorStop("0", particle.color);
				gradient.addColorStop("1.0", particle.color2);
				context.strokeStyle = gradient;
			} else
				context.strokeStyle = particle.color;
			context.moveTo(x, particle.y);
			context.lineTo(x2, y2);
			context.stroke();
		}
	}

	function updateParticles() {
		var width = window.innerWidth;
		var height = window.innerHeight;
		var particle;
		waveAngle += 0.01;
		for (var i = 0; i < particles.length; i++) {
			particle = particles[i];
			if (!streamingObject && particle.y < -15)
				particle.y = height + 100;
			else {
				particle.tiltAngle += particle.tiltAngleIncrement;
				particle.x += Math.sin(waveAngle);
				particle.y += (Math.cos(waveAngle) + particle.diameter + Object.speed) * 0.5;
				particle.tilt = Math.sin(particle.tiltAngle) * 15;
			}
			if (particle.x > width + 20 || particle.x < -20 || particle.y > height) {
				if (streamingObject && particles.length <= Object.maxCount)
					resetParticle(particle, width, height);
				else {
					particles.splice(i, 1);
					i--;
				}
			}
		}
	}
};