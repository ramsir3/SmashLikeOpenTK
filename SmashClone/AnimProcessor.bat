for /r %%i in (*.anim) do (
    python AnimProcessor.py %%i
    echo Processing %%i
)